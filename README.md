# PilotEdgeDiscordBot
This project uses the PilotEdge API to deliver textual ATIS based on current conditions.

## What can it do?

### ATIS `-METAR {ATIS}`
<img src="Readme%20GIFS/PE-ATIS.gif" width="70%">

When PilotEdge is available and online, the bot will retrieve the current ATIS. It will also return two emoji reactions to its message -- a colored circle indicating the field condition (VFR, IFR, MVFR, etc.) and a letter indicating the assigned ATIS letter.

### METAR `-METAR {ICAO}`
<img src="Readme%20GIFS/PE-METAR.gif" width="70%">

For fields with weather reporting, a METAR can be returned.

### No ATIS found or off network field
<img src="Readme%20GIFS/NONPE-WX.gif" width="70%">

If an identifier is provided and does not have ATIS available or is off network, the bot will return a METAR with a message indicating the situation.

## Future integrations

- [ ] Retrieve and file flight plans
- [ ] Track flight progress
- [ ] ATIS text to speech via audio channel
- [ ] Cleanup and streamline API access

## Resources
* [PilotEdge ATIS System](https://www.pilotedge.net/pages/atis-background) -- Provider of the PilotEdge weather information
* [AVWX](https://avwx.docs.apiary.io/) -- Provider of non-PilotEdge weather information (they have a lot of stuff!)
* [Discord Developer](https://discordapp.com/developers/docs/intro) -- Discord Developer
