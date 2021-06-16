pwdata <- read.table("PasswordResearch.csv", header=T, sep=',')

n_diffs <- function(expected, actual) {
  expected <- pwdata[expected]
  actual <- pwdata[actual]
  ret <- 0
  len <- min(nchar(expected), nchar(actual))
  for (i in c(1:len)) {
    if (substr(expected, i, i) != substr(actual, i, i)) {
      ret <- ret + 1
    }
  }
  ret <- ret + max(nchar(expected), nchar(actual)) - len
  ret
}

print(n_diffs("Expected PW", "Actual PW"))
