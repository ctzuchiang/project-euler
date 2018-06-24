import unittest
from python_wrap_cases import wrap_case
import LeetCode


@wrap_case
class TestSolutionFunc(unittest.TestCase):


    @wrap_case(list([2, 7, 11, 15]), int(9), list([0, 1]))
    @wrap_case(list([3,2,4]), int(6), list([1, 2]))
    def test_twoSum(self, nums, ans, expect):

        target = LeetCode.Solution()
        actual = target.twoSum(nums, ans)

        self.assertEqual(actual, expect)

if __name__ == '__main__':
    unittest.main()
