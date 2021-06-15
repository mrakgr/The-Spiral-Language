import numpy as np
import pyximport
pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
from hu_holdem import main
stack = 5
min_raise = 3
print(main())