// The types of these two will be replaced during compilation by the Spiral code generator. 
// It matches on `using default_int = ` and `;` with the inner part being replaced so the form should be kept as is. 
// The two statements need to begin at the start of a line.
using default_int = int;
using default_uint = unsigned int;

#ifndef __NVRTC__
// NVRTC has these includes by default so they need to be left out if it is used as the compiler.
#include <new>
#include <assert.h>
#include <stdio.h>
#endif

// For error checking on the host.
#define gpuErrchk(ans) { gpuAssert((ans), __FILE__, __LINE__); }
template <typename T> inline __host__ void destroy(T& obj) { obj.~T(); }
inline void gpuAssert(cudaError error, const char *file, int line, bool abort=true) {
    if (error != cudaSuccess) {
        fprintf(stderr, "GPUassert: %s %s %d\n", cudaGetErrorString(error), file, line);
        if (abort) exit(error);
    }
}

template <typename el>
struct sptr // Shared pointer for the Spiral datatypes. They have to have the refc field inside them to work.
{
    el* base;

    __host__ sptr() : base(nullptr) {}
    __host__ sptr(el* ptr) : base(ptr) { this->base->refc++; }

    __host__ ~sptr()
    {
        if (this->base != nullptr && --this->base->refc == 0)
        {
            delete this->base;
            this->base = nullptr;
        }
    }

    __host__ sptr(sptr& x)
    {
        this->base = x.base;
        this->base->refc++;
    }

    __host__ sptr(sptr&& x)
    {
        this->base = x.base;
        x.base = nullptr;
    }

    __host__ sptr& operator=(sptr& x)
    {
        if (this->base != x.base)
        {
            delete this->base;
            this->base = x.base;
            this->base->refc++;
        }
        return *this;
    }

    __host__ sptr& operator=(sptr&& x)
    {
        if (this->base != x.base)
        {
            delete this->base;
            this->base = x.base;
            x.base = nullptr;
        }
        return *this;
    }
};

template <typename el>
struct csptr : public sptr<el>
{ // Shared pointer for closures specifically.
    using sptr<el>::sptr;
    template <typename... Args>
    __host__ auto operator()(Args... args) -> decltype(this->base->operator()(args...))
    {
        return this->base->operator()(args...);
    }
};

template <typename el, default_int max_length>
struct static_array
{
    el ptr[max_length];
    __host__ el& operator[](default_int i) {
        assert("The index has to be in range." && 0 <= i && i < max_length);
        return this->ptr[i];
    }
};

template <typename el, default_int max_length>
struct static_array_list
{
    default_int length{ 0 };
    el ptr[max_length];

    __host__ el& operator[](default_int i) {
        assert("The index has to be in range." && 0 <= i && i < this->length);
        return this->ptr[i];
    }
    __host__ void push(el& x) {
        ptr[this->length++] = x;
        assert("The array after pushing should not be greater than max length." && this->length <= max_length);
    }
    __host__ void push(el&& x) {
        ptr[this->length++] = std::move(x);
        assert("The array after pushing should not be greater than max length." && this->length <= max_length);
    }
    __host__ el pop() {
        assert("The array before popping should be greater than 0." && 0 < this->length);
        auto x = ptr[--this->length];
        ptr[this->length].~el();
        new (&ptr[this->length]) el();
        return x;
    }
    // Should be used only during initialization.
    __host__ void unsafe_set_length(default_int i) {
        assert("The new length should be in range." && 0 <= i && i <= max_length);
        this->length = i;
    }
};

template <typename el, default_int max_length>
struct dynamic_array_base
{
    int refc{ 0 };
    el* ptr;

    __host__ dynamic_array_base() : ptr(new el[max_length]) {}
    __host__ ~dynamic_array_base() { delete[] this->ptr; }

    __host__ el& operator[](default_int i) {
        assert("The index has to be in range." && 0 <= i && i < this->length);
        return this->ptr[i];
    }
};

template <typename el, default_int max_length>
struct dynamic_array
{
    sptr<dynamic_array_base<el, max_length>> ptr;

    __host__ dynamic_array() = default;
    __host__ dynamic_array(bool t) : ptr(new dynamic_array_base<el, max_length>()) {}
    __host__ el& operator[](default_int i) {
        return this->ptr.base->operator[](i);
    }
};

template <typename el, default_int max_length>
struct dynamic_array_list_base
{
    int refc{ 0 };
    default_int length{ 0 };
    el* ptr;

    __host__ dynamic_array_list_base() : ptr(new el[max_length]) {}
    __host__ dynamic_array_list_base(default_int l) : ptr(new el[max_length]) { this->unsafe_set_length(l); }
    __host__ ~dynamic_array_list_base() { delete[] this->ptr; }

    __host__ el& operator[](default_int i) {
        assert("The index has to be in range." && 0 <= i && i < this->length);
        return this->ptr[i];
    }
    __host__ void push(el& x) {
        ptr[this->length++] = x;
        assert("The array after pushing should not be greater than max length." && this->length <= max_length);
    }
    __host__ void push(el&& x) {
        ptr[this->length++] = std::move(x);
        assert("The array after pushing should not be greater than max length." && this->length <= max_length);
    }
    __host__ el pop() {
        assert("The array before popping should be greater than 0." && 0 < this->length);
        auto x = ptr[--this->length];
        ptr[this->length].~el();
        new (&ptr[this->length]) el();
        return x;
    }
    // Should be used only during initialization.
    __host__ void unsafe_set_length(default_int i) {
        assert("The new length should be in range." && 0 <= i && i <= max_length);
        this->length = i;
    }
};

template <typename el, default_int max_length>
struct dynamic_array_list
{
    sptr<dynamic_array_list_base<el, max_length>> ptr;

    __host__ dynamic_array_list() = default;
    __host__ dynamic_array_list(default_int l) : ptr(new dynamic_array_list_base<el, max_length>(l)) {}

    __host__ el& operator[](default_int i) {
        return this->ptr.base->operator[](i);
    }
    __host__ void push(el& x) {
        this->ptr.base->push(x);
    }
    __host__ void push(el&& x) {
        this->ptr.base->push(std::move(x));
    }
    __host__ el pop() {
        return this->ptr.base->pop();
    }
    // Should be used only during initialization.
    __host__ void unsafe_set_length(default_int i) {
        this->ptr.base->unsafe_set_length(i);
    }
    __host__ default_int length_() {
        return this->ptr.base->length;
    }
};