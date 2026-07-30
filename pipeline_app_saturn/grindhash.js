import { sha3_256 } from "js-sha3";

export default class GrindHash {
    constructor(difficulty = 20){
        this.input = input;
        this.difficultyBits = difficultyBits;
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

    grindHash() {
        let nonce = 0;

        while (true) {
            const candidate = `${this.input}${nonce}`;
            const hash = keccak256(candidate);

            if (this.CountLeadingZeroBits(hash) >= this.difficultyBits) {
                return { nonce, hash };
            }

            nonce++;
        }
    }
}

module.export = GrindHash