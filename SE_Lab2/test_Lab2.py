import unittest
import SE_Lab2.Lab2 as Lab2

class TestLab2(unittest.TestCase):

    def test_generate_eratothenes_list(self):
        self.assertIsInstance(Lab2.generate_eratothenes_list(3)["list"], list)
        self.assertEqual(Lab2.generate_eratothenes_list(3)["list"],[2,3])
        self.assertEqual(Lab2.generate_eratothenes_list(3)["exit_code"],
                         1)
        self.assertEqual(Lab2.generate_eratothenes_list(3)["exit_message"],
                         "Exited Normally")

        self.assertEqual(Lab2.generate_eratothenes_list(100)["list"],[2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,
                                                              18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
                                                              32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45,
                                                              46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
                                                              60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
                                                              74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87,
                                                              88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100])
        self.assertEqual(Lab2.generate_eratothenes_list(100)["exit_code"],
                         1)
        self.assertEqual(Lab2.generate_eratothenes_list(100)["exit_message"],
                         "Exited Normally")
        #check ValueError
        self.assertEqual(Lab2.generate_eratothenes_list(1)["exit_code"], -1)
        self.assertEqual(Lab2.generate_eratothenes_list(1)["exit_message"], "Invalid input. Input must be an integer greater than 1 to produce prime number")

        self.assertEqual(Lab2.generate_eratothenes_list(0)["exit_code"], -1)
        self.assertEqual(Lab2.generate_eratothenes_list(0)["exit_message"],
                         "Invalid input. Input must be an integer greater than 1 to produce prime number")
        self.assertEqual(Lab2.generate_eratothenes_list(-1)["exit_code"], -1)  #check TypeError
        self.assertEqual(Lab2.generate_eratothenes_list(-1)["exit_message"],
                         "Invalid input. Input must be an integer greater than 1 to produce prime number")
        self.assertEqual(Lab2.generate_eratothenes_list(6.4)["exit_code"], -1)
        self.assertEqual(Lab2.generate_eratothenes_list(6.4)["exit_message"],
                         "Invalid input. Only integers allowed")
        self.assertEqual(Lab2.generate_eratothenes_list('2')["exit_code"], -1)
        self.assertEqual(Lab2.generate_eratothenes_list('2')["exit_message"],
                         "Invalid input. Only integers allowed")
        self.assertEqual(Lab2.generate_eratothenes_list('six')["exit_code"], -1)
        self.assertEqual(Lab2.generate_eratothenes_list('six')["exit_message"],
                         "Invalid input. Only integers allowed")
    def test_remove_composites(self):
        self.assertIsInstance(Lab2.remove_composites([2,3,-1,5,-1,7])["list"], list)
        self.assertEqual(Lab2.remove_composites([2,3,-1,5,-1,7])["list"],[2,3,5,7])
        self.assertEqual(Lab2.remove_composites([2,3,-1,5,-1,7])["exit_code"],
                         1)
        self.assertEqual(Lab2.remove_composites([2,3,-1,5,-1,7])["exit_message"],
                         "Exited Normally")

    def test_PrimeNumbers(self):

        #testing return type
        self.assertIsInstance(Lab2.PrimeNumbers(100)["list"], list)
        self.assertEqual(Lab2.PrimeNumbers(100)["list"],[2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97])
        self.assertEqual(Lab2.PrimeNumbers(100)["exit_code"], 1)
        self.assertEqual(Lab2.PrimeNumbers(100)["exit_message"], "Exited Normally")

        #edge case non perfect square
        self.assertIsInstance(Lab2.PrimeNumbers(80)["list"], list)
        self.assertEqual(Lab2.PrimeNumbers(80)["list"],[2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79])
        self.assertEqual(Lab2.PrimeNumbers(80)["exit_code"], 1)
        self.assertEqual(Lab2.PrimeNumbers(80)["exit_message"], "Exited Normally")

        #check TypeError

        self.assertEqual(Lab2.PrimeNumbers('100')["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers('100')["exit_message"], "Invalid input. Only integers allowed")
        self.assertEqual(Lab2.PrimeNumbers('six')["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers('six')["exit_message"], "Invalid input. Only integers allowed")
        self.assertEqual(Lab2.PrimeNumbers(6.4)["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers(6.4)["exit_message"], "Invalid input. Only integers allowed")

        #check ValueError as defined by a prime number is greater than 2
        self.assertEqual(Lab2.PrimeNumbers(1)["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers(1)["exit_message"], "Invalid input. Input must be an integer greater than 1 to produce prime number")
        self.assertEqual(Lab2.PrimeNumbers(0)["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers(0)["exit_message"],
                         "Invalid input. Input must be an integer greater than 1 to produce prime number")
        self.assertEqual(Lab2.PrimeNumbers(-1)["exit_code"], -1)
        self.assertEqual(Lab2.PrimeNumbers(-1)["exit_message"],
                         "Invalid input. Input must be an integer greater than 1 to produce prime number")

if __name__ == '__main__':
    unittest.main()

