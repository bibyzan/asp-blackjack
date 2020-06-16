// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


Object.defineProperty(Array.prototype, 'shuffle', {
    value: function () {
        for (let i = this.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [this[i], this[j]] = [this[j], this[i]];
        }
        return this;
    }
});


class Card {
    constructor(val, suit) {
        this.val = val;
        this.suit = suit;
    }

    toString() {
        let s = ['h', 's', 'c', 'd'];
        let v = ['a', '2', '3', '4', '5', '6', '7', '8', '9', 't', 'j', 'q', 'k'];

        return v[this.val - 1] + s[this.suit - 1] + '.gif';
    }

    calcVal() {
        //check for aces
        if (this.val > 10) {
            return 10;
        }
        else if (this.val == 1) {
            return 11;
        }
        else {
            return this.val;
        }
    }
}

class Deck {
    constructor() {
        this.cards = [];
        for (let suit = 1; suit <= 4; suit++) {
            for (let val = 1; val <= 13; val++) {
                this.cards.push(new Card(val, suit));
            }
        }
    }

    toString() {
        let str = "";

        for (let card of this.cards) {
            str += card.toString() + "\n";
        }

        return str;
    }
}

class Hand {
    constructor() {
        this.cards = [];
        this.score = 0;
        this.isAce = false;
    }

    addCard(draw) {
        this.score += draw.calcVal();
        this.cards.push(draw);
        if (draw.calcVal() == 11) {
            this.isAce = true;
        }
        if (this.score > 21 && this.isAce) {
            this.score -= 10;
        }
    }

    toString() {
        let str = '';

        for (let card of this.cards) {
            str += card.toString() + ' ';
        }

        return str;
    }

    reset() {
        this.isAce = false;
        this.score = 0;
        this.cards = [];
    }
}

class SessionPlayer {
    constructor() {
        this.chips = 20;
        this.name = '';
        this.wins = 0;
        this.losses = 0;
    }

    toString() {
        return this.name + " " + this.chips;
    }
}

class Blackjack {
    constructor() {
        this.dealer = new Hand();
        this.playerHand = new Hand();
        this.deck = new Deck();
        this.deckIndex = 0;
        this.bet = 0;
        this.player = new SessionPlayer();
    }


    start() {
        this.dealer.reset();
        this.playerHand.reset();
        this.deck.cards.shuffle();
        this.deckIndex = 0;
    }

    turn(hit = true) {
        if (hit) {
            this.playerHand.addCard(this.deck.cards[this.deckIndex]);
            this.deckIndex++;
        }
        if (this.dealerCheck()) {
            this.dealer.addCard(this.deck.cards[this.deckIndex]);
            this.deckIndex++;
        }
    }

    cardString(i) {
        return this.deck.cards[i].toString();
    }

    dealerCheck() {
        return this.dealer.score <= this.playerHand.score;
    }

    check() {
        if (this.playerHand.score == 21) {
            return 0;
        }
        else if (this.dealer.score == 21) {
            return 1;
        }
        else if (this.playerHand.score > 21) {
            return 2;
        }
        else if (this.dealer.score > 21) {
            return 3;
        }
        else if (this.playerHand.score < 21 && this.playerHand.score > this.dealer.score) {
            return 4;
        }
        else {
            return 5;
        }
    }

    result(c) {
        let r = [this.player.name + ' blackjack!', 'dealer blackjack!', this.player.name + ' busts', 'dealer busts', this.player.name + ' wins!', 'dealer wins!'];
        return r[c];
    }

    checkPlayerWin() {
        if ([0, 3, 4].includes(this.check())) {
            this.player.chips += (this.bet * 2);
            return true;
        }
        return false;
    }

    betChips(amount) {
        this.bet = amount;
        this.player.chips -= amount;
    }

    isGameOver() {
        return this.playerHand.score >= 21 || this.dealer.score >= 21;
    }
}

window.Blackjack = Blackjack;