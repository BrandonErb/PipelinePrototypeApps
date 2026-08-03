import { keccak256 } from "js-sha3";

export default class WorkHash {
    constructor(difficulty = 20){
        this.difficultyBits = difficulty;
        console.log(`Difficulty: ${difficulty}`)
    }


    countLeadingZeroBits(hexHash) {
        let bits = 0;

        for (let i = 0; i < hexHash.length; i++) {
            const nibble = parseInt(hexHash[i], 16);

            if (nibble === 0) {
                bits += 4;
                continue;
            }

            if (nibble < 8) bits += 1;
            if (nibble < 4) bits += 1;
            if (nibble < 2) bits += 1;

            break;
        }

        return bits;
    }

    grindWork(input) {
        let nonce = 0;
        console.log(`Hashing on:${input}`)
        while (true) {
            const attempt = `${this.input}${nonce}`;
            const hash = keccak256(attempt);
            console.log(`Solve attempt: ${nonce}:{hash}`)
            if (this.countLeadingZeroBits(hash) >= this.difficultyBits) {
                console.log(`Solved on nonce: ${nonce}`)
                return { nonce, hash }; //Hash is meaningless as it is always the same for each difficulty with current code
            }

            nonce++;
        }
    }
}