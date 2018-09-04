
import math
import time


def generate_eratothenes_list(x):
    if type(x) is not int:
        raise TypeError("Invalid input. Only integers permitted.")
    
    if x < 2:
        raise ValueError("Prime numbers can only be generated for values greater than 1.")
    return list(range(2, x+1))
    

def remove_composites(all_numbers):
      return list((value for value in all_numbers if value != -1))

def PrimeNumbers(x):
  
    all_numbers = generate_eratothenes_list(x)

    # Optimization to stop at squareroot of number X
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
                    raise RuntimeError("Program took longer than usual to return. Try a smaller input.")

                if(a != -1 and a != current_number and a%current_number ==0):
                   all_numbers[all_numbers.index(a)] = -1

    #Remove all marked values, these are all NOT prime
    all_numbers[:] = remove_composites(all_numbers)
    
    return all_numbers
            


