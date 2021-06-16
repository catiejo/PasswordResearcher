ggplot(data=fpws, 
       aes(x=time_enter, y=diffs, colour=Masked)) + 
  geom_jitter(alpha=1/2) +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5))
ggsave("MaskedVsUnmasked.png")

ggplot(data=fpws, 
       aes(x=time_enter, y=diffs, colour=`PW Type`)) + 
  geom_jitter(alpha=1/2) +
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5))
ggsave("MaskedVsUnmaskedvsPWType.png")


ggplot(data=fpws, 
       aes(x=Masked, y=time_enter, colour=Masked)) + 
  geom_boxplot() + 
  facet_grid(rows = vars(diffs)) +
  coord_flip()
ggsave("MaskedVsUnmaskedBox.png")

ggplot(data=fpws, 
       aes(x=diffs, y=time_enter, colour=cut(diffs, c(-Inf, 0, 1, 2, 3, 4)))) + 
  geom_boxplot() + 
  coord_flip()
ggsave("TimeVsDiffs.png")

ggplot(data=fpws, 
       aes(x=time_enter, y=diffs, colour=Masked)) + 
  geom_point() + 
  facet_grid(`PW Type` ~ OS)
ggsave("OSVsTypeVsMasked.png")

ggplot(data=fpws, 
       aes(x=time_enter, y=diffs, colour=Masked)) + 
  geom_point() + 
  scale_y_continuous(breaks=2*c(1:5), labels=2*c(1:5)) +
  facet_grid(`PW Type` ~ OS)
ggsave("OSVsTypeVsMaskedFiltered.png")

ggplot(data=fpws,
       aes(y=time_enter, x=OS, colour=Participant)) + 
  geom_boxplot() + 
  facet_grid(`PW Type` ~ Masked)
ggsave("TimeVsOSMaskedParticipants.png")


ggplot(data=fpws, 
       aes(x=Masked, y=time_enter, colour=Masked)) + 
  geom_boxplot() + 
  facet_grid(rows = vars(diffs)) +
  coord_flip()
ggsave("MaskingvsTimevsDiffs.png")

ggplot(data=fpws, 
       aes(x=Masked, y=time_enter, colour=Masked)) + 
  geom_jitter() + 
  facet_grid(rows = vars(diffs)) +
  coord_flip()
ggsave("MaskingvsTimevsDiffsJitter.png")


ggplot(data=fpws, 
       aes(x=Masked, y=time_enter, colour=Masked)) + 
  geom_boxplot() + 
  coord_flip()
ggsave("MaskingvsTime.png")


ggplot(data=fpws, 
       aes(x=`PW Type`, y=time_enter, colour=`PW Type`)) + 
  geom_boxplot() + 
  coord_flip()
ggsave("EntryTimevsPWType.png")

ggplot(data=fpws, 
       aes(x=Participant, y=time_enter, colour=`Participant`)) + 
  geom_boxplot() + 
  facet_grid(rows=vars(`PW Type`))
ggsave("TypingSpeedvsPWType.png")

ggplot(data=fpws, 
       aes(x=Participant, y=time_enter, colour=`Participant`)) + 
  geom_boxplot()
ggsave("BestEva.png")
