players = [
    f'nn_agent_{i}_{mode}{momo}' 
    for momo in ['no_momo','momo']
    for mode in ['','self_','average_'] 
    for i in [260,280,300,320,340,360]
    ]
print(players)