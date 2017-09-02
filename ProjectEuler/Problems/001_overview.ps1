<#
    If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    Find the sum of all the multiples of 3 or 5 below 1000.
#>

<#
[int]$limit = 1000;
[int]$sum = 0;
for ($i = 1; $i -lt $limit; $i++) {
    if (($i % 3 -eq 0) -or ($i % 5 -eq 0)) {
        $sum += $i; 
    }
}

Write-Host "sum = "$sum;
#>

[int]$limit = 999;

function SumDivisibleBy ($n) {
    $p = [math]::Floor($limit / $n);
    return $n*($p*($p+1))/2;
}
$x = SumDivisibleBy(3);
$y = SumDivisibleBy(5);
$z = SumDivisibleBy(15);

Write-Host ($x + $y - $z);
