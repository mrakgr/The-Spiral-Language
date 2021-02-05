import pyximport
pyximport.install(language_level=3)
import tailrec
print(tailrec.sequence_tailrec(0,2_000_000_000))

