#!/usr/bin/env node

import amqp from "amqplib";
import WorkHash from "./work_hash.js";

async function main() {
    const connection = await amqp.connect({
        hostname: "localhost",
        port: 5672,
        username: "user",
        password: "password",
    });
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

        console.log("[rec] data: %s", message);

        const work = new WorkHash(16);
        const result = work.grindWork(message);
        const response = result.hash

        channel.sendToQueue(msg.properties.replyTo,
            Buffer.from(response.toString()), {
              correlationId: msg.properties.correlationId
            });

        channel.ack(msg);
    });
    console.log("Found Hash!");
}


main();