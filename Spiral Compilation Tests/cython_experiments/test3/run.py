import pyximport
pyximport.install(language_level=3)
from testm import (applyAdd,FuncAddInt)
print(applyAdd(FuncAddInt(1),2))
