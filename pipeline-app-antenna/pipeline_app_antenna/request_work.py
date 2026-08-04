import requests
import json
import aiohttp

class RequestWork:

    def __init__(self, workServiceUrl):
        self.api_url = workServiceUrl

    
    async def send_work(self, input): 
        message = '"' + input + '"' #need to send a JSON string body
        print(f"POST request: {self.api_url}/{message}")

        headers = {"Accept": "application/json", "Content-Type": "application/json"}
        async with aiohttp.ClientSession() as session:
            async with session.post(url=self.api_url, json=message, headers=headers) as response:
                result = await response.text()
                print(f"Response: amount of attempts to solve - {result}")