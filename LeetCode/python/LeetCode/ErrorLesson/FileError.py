import sys
 
filePath = 'D:\dev\Joseph\project-euler\LeetCode\python\LeetCode\ErrorLesson\\test.txt'
try:
    f = open(filePath)
    s = f.readline()
    i = int(s.strip())
except OSError as err:
    print("OS error: {0}".format(err))
except ValueError:
    print("Could not convert data to an integer.")
except:
    print("Unexpected error:", sys.exc_info()[0])
    raise
else:
    print("test.txt has", len(s),'lines')
    f.close()
finally:
    print("Last Step")