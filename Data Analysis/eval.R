library(tidyverse)
library(utils)

# n_diffs computes the difference between two passwords.
#
# The passwords are input as a string array of size at least two.
# Only the first two elements of the array are used.
#
# This is a very slow function that is not fit for big data.
# Emphasis was on obvious correctness, not speed.
#
n_diffs <- function(pws) {
  expected <- pws[1]
  actual <- pws[2]
  return(adist(expected, actual)[1,1])
}

pws <- read_csv("PasswordResearch.csv")

# Create two new columns:
#
# * time_enter - how long did it take to enter the password
# * diffs - the number of errors made
pws <- mutate(pws, time_enter=`Time End` - `Time Start`,
              diffs=apply(cbind(pws$`Expected PW`, pws$`Actual PW`), 1, n_diffs),
              pwlen=nchar(`Expected PW`))


# Filtered data: Exclude outliers
fpws <- filter(pws, diffs <= 10, time_enter <= 100)
mfpws <- filter(fpws, Masked == "Masked")
umfpws <- filter(fpws, Masked == "Unmasked")
typical_fpws <- filter(fpws, `PW Type` == "Typical")
phrase_fpws <- filter(fpws, `PW Type` == "Phrase")
random_fpws <- filter(fpws, `PW Type` == "Random")