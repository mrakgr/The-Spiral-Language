import numpy
import pyximport
pyximport.install(language_level=3,setup_args={"include_dirs":numpy.get_include()})
from testm import (main)
print(main())

