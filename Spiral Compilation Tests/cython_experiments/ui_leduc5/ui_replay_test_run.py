import numpy as np
import pyximport
pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
from ui_replay_test import main
print(main())

# import numpy as np
# q = np.array([1,2,3])
# t = q
# w = np.array([3,4,5])
# t += w
# print(t)