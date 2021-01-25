import pyximport
pyximport.install(language_level=3)
import tuple_test
# print(tail_rec.sequence(0,2_000_000_000)) # Diverges
print(tuple_test.qwe(1,2))

