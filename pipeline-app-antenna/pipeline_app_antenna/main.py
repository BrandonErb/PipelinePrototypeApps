from random import randint
import secrets
import string
import time
from request_work import RequestWork

INPUT_LENGTH = 12
DELAY_MIN = 10
DELAY_MAX = 20

def main():
    try:
        while True:
            time.sleep(randint(DELAY_MIN, DELAY_MAX))
            random_input = ''.join(secrets.choice(string.digits + "XE") for _ in range(INPUT_LENGTH))
            do_work = RequestWork("http://localhost:5201/api/worksaturn")
            do_work.send_work(random_input)
            #check result to see if it valid
    except KeyboardInterrupt: #want SIGINT to kill gracefully 
        pass


if __name__ == '__main__':
    main()
