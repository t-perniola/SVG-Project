<!-- aggiungere badge -->
[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=flat&logo=unity)](https://unity3d.com)

# Annunci / Status del progetto
> Status demo: completa

Attualmente è disponibile solo una demo del progetto scaricabile nella seguente [sezione](https://github.com/t-perniola/SVG-Project/releases) della repository.

# SVG-Project

## Immagini
![image](https://user-images.githubusercontent.com/64893048/177182375-789b0afd-bc36-45bf-a443-ebe44a0a1e9b.png)

![image](https://user-images.githubusercontent.com/64893048/177182456-c04ee4cb-3c83-4eed-93de-b4242929d260.png)

![image](https://user-images.githubusercontent.com/64893048/177182569-39da3e18-4ee3-49c5-93b9-c933e297e26d.png)

![image](https://user-images.githubusercontent.com/64893048/177182745-1b836587-e3d6-4480-b2e3-389bb22bf3cb.png)

# Indice

- [Come iniziare](#come-iniziare)
  - [Come installare](#come-installare)
  - [Tutorial e comandi](#tutorial-e-comandi)
    - [Lista dei comandi](#lista-dei-comandi)
  - [Documentazione](#documentazione)
  - [Game Design Document](#game-design-document)
- [Struttura del progetto](#struttura-del-progetto)
  - [Segnalazione bug e miglioramenti](#segnalazione-bug-e-miglioramenti)
- [Manutenzione](#manutenzione)
- [Licenza](#licenza)
  - [Autori](#autori)
  - [Licenze software dei componenti di terze parti](#licenze-software-dei-componenti-di-terze-parti)

# Come iniziare

## Come installare
Per provare la demo basta scaricare il file .rar contenuto nella sezione Releases, decomprimerlo e avviare l'eseguibile.

Per eseguire la demo utilizzando Unity occorre clonare la repository sul proprio computer ed aprirla in locale.

> **Nota**: la demo è stata realizzata con la versione 2020.3.32f1 di Unity

## Tutorial e comandi
La demo si articola in 3 fasi con 3 meccaniche di gioco principali che si susseguiranno automaticamente al completamento di alcune attività:

1. Fase esplorativa: interagire con il computer con schermo verde presente nell'officina
2. Fase TPS mounted (su navicella): raggiungere l'obiettivo con scritto "Entrata" nel tempo limite
3. Fase TPS ranged (con armi da fuoco): sconfiggere tutti i nemici e il boss al piano superiore nella zona sinistra del corridoio

### Lista dei comandi
```
--- Fase esplorativa ---
Movimento giocatore: WASD
Movimento telecamera: MOUSE
Sprint: SHIFT SX
Salto: SPACEBAR
Interazione mentore: M (funzioni interne non implementate)

--- Fase TPS mounted ---
Movimento navicella: WAS
Rotazione destra: E
Rotazione sinistra: Q
Movimento telecamera: MOUSE
Sprint: SHIFT SX
Sparare: CLICK SX

--- Fase TPS ranged ---
Movimento giocatore: WASD
Movimento telecamera: MOUSE
Sprint: SHIFT SX
Salto: SPACEBAR
Mirare: CLICK DX
Sparare: CLICK SX
```

## Documentazione
### Game Design Document
Link per il documento completo: [clicca qui](https://github.com/t-perniola/SVG-Project/blob/ester3/Game%20Design%20Document.pdf)

Viene riportato un riassunto di alcune sezioni del GDD

# Struttura del progetto
La struttura del progetto segue lo standard dei progetti realizzati in Unity. La cartella Assets nello specifico è così organizzata:

```
|-- Assets
|   |-- Ambienti
|   |   |-- A_piece_of_nature
|   |   |-- DeepSpaceSkyboxPack
|   |   |-- Sci-Fi Styled Modular Pack
|   |   |-- Particle Dissolve Shader by Moonflower Carnivore
|   |-- Personaggi
|   |   |-- Apache
|   |   |-- drone
|   |   |-- EnemyRobots
|   |   |-- Skechfab
|   |   |-- RealisticCharacter
|   |   |-- SpaceshipsModels
|   |   |-- StarSparrow
|   |   |-- StarterAssets
|   |   |-- ModularFirstPersonController
|   |   |-- Import
|   |-- Scripts
|   |-- Sketchfab For Unity
|   |-- Audio
|   |   |-- Space SFX - 102218
|   |   |-- Music
|   |-- Plugins
|   |-- Scenes
|   |-- UI
|   |   |-- Unity UI Samples
|   |   |-- Sci-Fi UI
```

## Segnalazione bug e miglioramenti
Nel caso in cui dovesse essere presente un bug o una proposta per migliorare il progetto, è possibile creare una nuova [Issue](https://github.com/t-perniola/SVG-Project/issues/new) in questa repository.

# Manutenzione
La manutenzione del progetto è attualmente supportata dagli stessi autori.

# Licenza

## Autori
- Tommaso ([GitHub](https://github.com/t-perniola))
- Luca ([GitHub](https://github.com/lucazeverino))
- Ester ([GitHub](https://github.com/burraco135))
- Giacomo ([GitHub](GiacomoSignorile))

## Licenze software dei componenti di terze parti
Il progetto è stato realizzato con licenza software [Unity Personal](https://store.unity.com/products/unity-personal).
