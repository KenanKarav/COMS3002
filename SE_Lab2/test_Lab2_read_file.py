import unittest
from ast import literal_eval
from decimal import Decimal

import Lab2 as Lab2

class TestLab2(unittest.TestCase):

    def test_generate_eratothenes_list(self):
        
        with open("test_generate_eratothenes_list.txt", "r") as f:
     
            lines = f.read().splitlines()
           
            for line in lines:
                parameter = line.split(";")[0]
                if "." not in parameter:
                    if('\'' in parameter):
                       parameter= parameter#str
                    else:
                        parameter = int(parameter)
                  
                else:
                    parameter = Decimal(parameter.replace(',',''))
            
                dictIndex = line.split(";")[1] 
                expectedOutput = line.split(";")[2]
                expectedOutputType = int(line.split(";")[3]) #can take on values: 0-list(object), 1-list, 2-str,3-int
   
                if(expectedOutputType == 0): #list(object)
                    self.assertIsInstance(Lab2.generate_eratothenes_list(parameter)[dictIndex], list)
                elif(expectedOutputType == 1):#list
                    array = literal_eval(expectedOutput)
                    self.assertEqual(Lab2.generate_eratothenes_list(parameter)[dictIndex],array)
                elif(expectedOutputType == 2):#str
                    self.assertEqual(Lab2.generate_eratothenes_list(parameter)[dictIndex],expectedOutput)
                elif(expectedOutputType == 3):#int
                    self.assertEqual(Lab2.generate_eratothenes_list(parameter)[dictIndex],int(expectedOutput))

    def test_remove_composites(self):           
         with open("test_remove_composites.txt", "r") as f:
     
            lines = f.read().splitlines()
            for line in lines:
               # testType = int(line.split(";")[0])
                parameter = literal_eval(line.split(";")[0])
                dictIndex = line.split(";")[1] 
         
                expectedOutput = line.split(";")[2]
              
                expectedOutputType = int(line.split(";")[3]) #can take on values: 0-list(object), 1-list, 2-str,3-int

   
                if(expectedOutputType == 0): #list(object)
                    self.assertIsInstance(Lab2.remove_composites(parameter)[dictIndex], list)
                elif(expectedOutputType == 1):#list
                    array = literal_eval(expectedOutput)
                    
                   
                    self.assertEqual(Lab2.remove_composites(parameter)[dictIndex],array)
                elif(expectedOutputType == 2):#str
                    self.assertEqual(Lab2.remove_composites(parameter)[dictIndex],expectedOutput)
                elif(expectedOutputType == 3):#int
                    self.assertEqual(Lab2.remove_composites(parameter)[dictIndex],int(expectedOutput))

    def test_PrimeNumbers(self): 
         
        with open("test_PrimeNumbers.txt", "r") as f:
            lines = f.read().splitlines()
           
            for line in lines:
                parameter = line.split(";")[0]
                if "." not in parameter:
                    if('\'' in parameter):
                       parameter= parameter#str
                    else:
                        parameter = int(parameter)
                else:
                    parameter = Decimal(parameter.replace(',',''))
            
                dictIndex = line.split(";")[1] 
         
                expectedOutput = line.split(";")[2]

                expectedOutputType = int(line.split(";")[3]) #can take on values: 0-list(object), 1-list, 2-str,3-int

   
                if(expectedOutputType == 0): #list(object)
                    self.assertIsInstance(Lab2.PrimeNumbers(parameter)[dictIndex], list)
                elif(expectedOutputType == 1):#list
                    array = literal_eval(expectedOutput)
                    self.assertEqual(Lab2.PrimeNumbers(parameter)[dictIndex],array)
                elif(expectedOutputType == 2):#str
                    self.assertEqual(Lab2.PrimeNumbers(parameter)[dictIndex],expectedOutput)
                elif(expectedOutputType == 3):#int
                    self.assertEqual(Lab2.PrimeNumbers(parameter)[dictIndex],int(expectedOutput))         
       

if __name__ == '__main__':
    unittest.main()
