FROM python:3.14.6-slim
WORKDIR /app
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt
COPY . .
WORKDIR /app/pipeline_app_antenna
ENV PYTHONUNBUFFERED=1
CMD ["python", "main.py"]
