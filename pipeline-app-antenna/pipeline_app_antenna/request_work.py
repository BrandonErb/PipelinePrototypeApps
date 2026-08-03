import requests
import json


class RequestWork:

    def __init__(self, workServiceUrl):
        self.api_url = workServiceUrl

    
    def send_work(self, input):
        message = '"' + input + '"' #need to send a JSON string body
        print(f"POST request: {self.api_url}/{message}")
        response = requests.post(self.api_url, json=message, headers={    "Accept": "application/json", "Content-Type": "application/json"}, timeout=30)
        print(f"Response: solved hash - {response.text}")