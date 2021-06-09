import pickle

path = 'dump/agent.data'
def store(d):
    f = open(path,'wb')
    pickle.dump(d,f)

store('qweqwzxczxce')
with open(path,'rb') as f: 
    print(pickle.load(f))