function Game {
    begin {
        $scores = 0, 0
        
        function to_string ($score) {
            switch ($score) {
                0 { "0" }
                1 { "15" }
                2 { "30" }
                3 { "40" }
                3.5 { "Advantage" }
                4 { "Won" }
                default { $score }
            }
        }

        function is_deuce {
            return $scores[0] -eq 3 -and $scores[1] -eq 3
        }

        function has_advantage ($player) {
            return $scores[$player] -eq 3.5
        }
        
        function opponent ($player) {
            ($player + 1) % 2
        }
    }
    process {
        if ($null -eq $_) { return }
        
        if ((is_deuce) -or (has_advantage $_)) {
            $scores[$_] += 0.5
        }
        elseif (has_advantage(opponent $_)) {
            $scores[(opponent $_)] -= 0.5
        }
        else {
            $scores[$_]++
        }
    }
    end {
        "$(to_string $scores[0]) : $(to_string $scores[1])"
    }
}

(game) -eq "0 : 0"

(0 | game) -eq "15 : 0"

(0, 0 | game) -eq "30 : 0"

(0, 0, 0 | game) -eq "40 : 0"

(0, 0, 0, 0 | game) -eq "Won : 0"

(0, 0, 0, 1, 1, 1, 1 | game) -eq "40 : Advantage"

(0, 0, 0, 1, 1, 1, 1, 1 | game) -eq "40 : Won"

(0, 0, 0, 1, 1, 1, 1, 0 | game) -eq "40 : 40"
