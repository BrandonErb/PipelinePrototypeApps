#!/usr/bin/env node

const amqp = require('amqplib');

async function main() {
  const connection = await amqp.connect('amqp://localhost');
  const channel = await connection.createChannel();

  const queue = 'work_rpc';

  await channel.assertQueue(queue, {
    durable: true,
    arguments: {
      'x-queue-type': 'quorum'
    }
  });
  channel.prefetch(1);
  console.log(' [x] Awaiting RPC requests');
  channel.consume(queue, function reply(msg) {
    const message = msg.content

    console.log(" [rec] data(%s)", message);

    const r = fibonacci(n);

    channel.sendToQueue(msg.properties.replyTo,
      Buffer.from(r.toString()), {
        correlationId: msg.properties.correlationId
      });

    channel.ack(msg);
  });
}


main();