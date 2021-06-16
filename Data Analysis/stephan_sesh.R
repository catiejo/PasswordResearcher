library(tidyverse)
library(utils)
pws$`Actual PW` #only display the "Actual PW" column
filter(pws, diffs>5)$diffs #filters the data to more than 5 diffs and displays the number of diffs
?aes # how to look up the help for a function
table(pws$diffs) # how many of each number of diffs are in the data?
cbind(largeerr$`Expected PW`, largeerr$`Actual PW`) #column bind
rbind(largeerr$`Expected PW`, largeerr$`Actual PW`) # row bind
source('~/Documents/Theses/ZHAW/EVA-PasswordBox/eval.R')
fpws <- filter(pws, time_enter < 200, diffs < 5) # data we're using

# Time vs Diffs -- kitchen sink
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Masked)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ OS)

# Time vs Diffs -- masked/unmasked
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Masked)) +
  geom_point(alpha=1/2) +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5))

ggplot(data=fpws,
       aes(y=time_enter, x=OS, colour=Participant)) +
  geom_boxplot() +
  facet_grid(`PW Type` ~ Masked)
boxplot(fpws$diffs)
hist(fpws$diffs)
ggplot(data=fpws,
       aes(y=time_enter, x=OS, colour=Participant)) +
  geom_boxplot() +
  facet_grid(`PW Type` ~ Masked)
source('~/Documents/Theses/ZHAW/EVA-PasswordBox/eval.R')
ggplot(data=fpws,
       aes(y=time_enter, x=OS, colour=Participant)) +
  geom_boxplot() +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=pws,
       aes(y=time_enter, x=OS, colour=Participant)) +
  geom_boxplot() +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=fpws,
       aes(y=time_enter, x=OS, colour=Participant)) +
  geom_boxplot() +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Masked)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ OS)
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_boxplot() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ OS)
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ OS)
ggplot(data=fpws,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
apwd <- filter(fpws, `Type Attempt Number` == 1)
ggplot(data=apws,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=apw,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=apwd,
       aes(x=time_enter, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
p <- filter(apwd, diffs > 0)
p
View(p)
View(p)
View(p)
View(p)
ggplot(data=apw,
       aes(x=`Num Backspaces`, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=fpws,
       aes(x=`Num Backspaces`, y=diffs, colour=Participant)) +
  geom_point() +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ Masked)
ggplot(data=fpws,
       aes(x=`Num Backspaces`, y=diffs, colour=Participant)) +
  geom_point()
ggplot(data=fpws,
       aes(x=`Num Backspaces`, y=diffs, colour=Participant)) +
  geom_point(alpha=1/10)
ggplot(data=fpws,
       aes(x=`Num Backspaces`, y=diffs, colour=Participant)) +
  geom_point(alpha=1/2)
hist(fpws$`Num Backspaces`)
ggplot(data=fpws,
       aes(y=`Num Backspaces`, y=Masked, colour=Participant)) +
  geom_point(alpha=1/2)
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=Masked, colour=Participant)) +
  geom_point(alpha=1/2)
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=Masked, colour=Participant)) +
  geom_boxplot()
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=Masked)) +
  geom_boxplot()
View(fpws)
View(fpws)
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point()
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point(alpha=1/2)
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point(alpha=1/3)
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point(alpha=1/3) + geom_jitter()
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point() + geom_jitter()
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant, colour=diffs)) +
  geom_point() + geom_jitter()
ggplot(data=fpws,
       aes(y=`diffs`, x=Participant)) +
  geom_point() + geom_jitter()
ggplot(data=fpws,
       aes(y=`diffs`, x=Masked)) +
  geom_point() + geom_jitter()
ggplot(data=fpws,
       aes(y=`time_enter`, x=Masked)) +
  geom_point() + geom_jitter()
ggplot(data=fpws,
       aes(y=`time_enter`, x=Masked)) +
  geom_boxplot()
ggplot(data=fpws,
       aes(y=`time_enter`, x=`PW Type`)) +
  geom_boxplot()
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=`PW Type`, colour=Masked)) +
  geom_boxplot()
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=`PW Type`, colour=Masked)) +
  geom_boxplot() +facet_wrap(~diffs)
m <- mutate(fpws, pwlen = nchar(`Expected PW`))
View(m)
ggplot(data=fpws,
       aes(y=`Num Backspaces`, x=`pwlen`, colour=Masked)) +
  geom_boxplot()
ggplot(data=m,
       aes(y=`Num Backspaces`, x=`pwlen`, colour=Masked)) +
  geom_boxplot()
ggplot(data=m,
       aes(y=`Num Backspaces`, x=`pwlen`, colour=Masked)) +
  geom_point()
model <- lm(`Num Backspaces` ~ pwlen, data=m)
model
summary(model)
abline(model)