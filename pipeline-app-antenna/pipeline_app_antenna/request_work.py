import requests
import json


class RequestWork:

    def __init__(self, workServiceUrl):
        self.api_url = workServiceUrl

    
    def send_work(self, message):
        print(f"POST request: {self.api_url}/{message}")
        response = requests.post(self.api_url, data={'message': message})
        print(f"Response: solved hash - {response.text}")