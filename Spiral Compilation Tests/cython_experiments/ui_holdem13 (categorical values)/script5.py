from math import log, exp

def g_for(x):
    return exp(x)

def g_back(y):
    return log(y)

def f_for(x):
    return x * (exp(1) - 1) + 1

def f_back(y):
    return (y - 1) / (exp(1) - 1)

# print((f_back(1.5)))

tzl = 1.0
tz = g_for(0.4)
tzu = exp(1)
print(tzl,tz,tzu)
print((tz - tzl) / (tzu - tzl))
print(f_back(tz))
