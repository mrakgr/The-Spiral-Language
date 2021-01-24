from distutils.core import setup
from Cython.Build import cythonize
import os

path = "test_cy.pyx" # os.path.join(os.path.dirname(__file__),"test_cy.pyx")
setup(ext_modules=cythonize(path))