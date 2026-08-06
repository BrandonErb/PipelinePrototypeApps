from random import randint
import secrets
import string
import asyncio
from request_work import RequestWork

INPUT_LENGTH = 12
DELAY_MIN = 10
DELAY_MAX = 30

async def main():
    tasks = set()
    try:
        while True:
            await asyncio.sleep(randint(DELAY_MIN, DELAY_MAX)) #Allow queue to clear if any messages are stuck
            random_input = ''.join(secrets.choice(string.digits + "XE") for _ in range(INPUT_LENGTH))
            do_work = RequestWork("http://server:5201/api/worksaturn")

            task = asyncio.create_task(do_work.send_work(random_input))
            tasks.add(task)
            task.add_done_callback(tasks.discard)

            #check result to see if it valid?
    except asyncio.CancelledError: #want SIGINT to kill gracefully 
        for task in tasks:
            task.cancel()
        await asyncio.gather(*tasks, return_exceptions=True)
        raise
        


if __name__ == '__main__':
    try:
        asyncio.run(main())
    except:
        pass