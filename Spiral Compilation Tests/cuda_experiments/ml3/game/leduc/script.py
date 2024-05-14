import random

my_list = [1, 2, 3, 4, 5]
shuffled_list = random.sample(my_list, len(my_list))

print(shuffled_list.pop())  # Output will be a shuffled list (different from original)
print(my_list)       # Original list remains unchanged
