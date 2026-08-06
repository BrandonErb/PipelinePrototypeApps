# PipelinePrototypeApps
This is a set of apps that can be used to test DevOps deployments. It has automated input, webserver, and workers. 
It is a functional state, the rabbitmq server is the official image run in a separate docker container using default ports.

## PipelineAppSun
The Kestrel webserver, it takes http requests from a frontend and trasmits those request to a worker via RabbitMQ.

## pipeline-app-antenna
A variant of the frontend that is a python script that automatically sends work with http requests. Sends random duodecimal numbers at random intervals. 

## pipeline_app_saturn
A variant of a worker that receives a request from rabbitmq. It grinds a hash and sends the result as a callback to the server. The workers speed/load is defined by difficulty, which is the number of leading zero bits to ignore when trying to equate the hash. 


# Todo
- Change request and message to json containing input number, difficulty, workId.
- Add env vars for each const with .env file fallback for testing. 
- Allow different workers through their own endpoints
- Code fileio and memory allocation workers
- Replace RabbitMQ default round robin behavior with a loadbalancer
- Add app for data access layer to manage work tracking on a relational database.
- Re-write workers in Rust & Go 