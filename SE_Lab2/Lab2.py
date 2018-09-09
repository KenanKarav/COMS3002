
import math
import time


def generate_eratothenes_list(x):
    if type(x) is not int:
        return {"exit_code": -1,
                "exit_message": "Invalid input. Only integers allowed",
                "list": []}
    
    if x < 2:
        return {"exit_code": -1,
                "exit_message": "Invalid input. Input must be an integer greater than 1 to produce prime number",
                "list": []}
    number_list = list(range(2, x+1))
    return {"exit_code": 1,
     "exit_message": "Exited Normally",
     "list": number_list}
    

def remove_composites(all_numbers):
      return {"exit_code": 1,
                "exit_message": "Exited Normally",
                "list": list((value for value in all_numbers if value != -1))}

def PrimeNumbers(x):

    list_dict = generate_eratothenes_list(x)
    if(list_dict["exit_code"] == 1):
        all_numbers = list_dict["list"]
    else:
        return list_dict
    # Optimization to stop at square root of number X
    index_of_sqrt = all_numbers.index(math.ceil(math.sqrt(x)))

    start_time = time.time()
    #Sieve of Eratothenes Algorithm
    for pos in range(0, index_of_sqrt+1):
        current_number = all_numbers[pos]
        # Skip marked values 
        if(current_number != -1):
            for a in all_numbers:
                end_time = time.time() - start_time
                if(end_time > 10):
                    return {"exit_code": -1,
                "exit_message": "Runtime exceeded, try a smaller input",
                "list": []}

                if(a != -1 and a != current_number and a%current_number ==0):
                   all_numbers[all_numbers.index(a)] = -1

    #Remove all marked values, these are all NOT prime
    all_numbers[:] = remove_composites(all_numbers)["list"]

    
    return {"exit_code": 1,
                "exit_message": "Exited Normally",
                "list": all_numbers}




