Pet Adopter
Team Earth Kingdom's Project



Group API Project - Project Assessment

Our team chose to build a PetAdopter API using .NET Framework API Web Application with an n-tier architecture with layers for Data, Logic, and Presentation.


The PetAdopter API includes four tables: Shelter - Jonah, Adopter - Andrew, Domestics - Stacy, and Exotics - Jake. 

Our team spent two days brainstorming and plotting out our project, which included: 

* Using Dbdiagram.io, we plotted out our tables and the foreign keys that would link them. 
* Using Trello, we used Agile methods to plot and plan our to do list, user stories, MVP list, 
  stretch goals, and personal to do lists as well as completion lists.
* We reviewed our proposed project with Instructor Andrew Torr using Zoom to share our Dbdiagram.io link.
* We used Instructor Andrew's advice and feedback to make adjustments to our database and planning materials.
* For the planning document, we worked together, with Jonah typing, to fill out the document before submission. As our project changed, so did our document. Changes were made to   the database structures as well as our planning schedule. We anticpate further changes as the project progresses.
* Using GitHub, we each created our own branches, as well as Dev and Master branches. Multiple times a day each team member pulled, pushed, and merged their commits to make one   cohesive API.
 

The PetAdopter API has been built with the idea that shelters can post the pets they have available for adoption. Individual user accounts with authorization are required to post values to the tables of the database. These tables include: shelter, adopter, domestic, and exotic. 

Upon running the API, a user is able to create an authorized user account and request a token.

With this token the user is able to:

**Shelters, which includes the name, city, state, and phone number of the shelter. A shelterid is automatically assigned to the shelter upon creation.
    
    -Available endpoints in the shelter controller are POST, GET, PUT, DELETE.
        -Post allows for a user to add a new shelter.
        -Get: Two instances are included: Get All Shelters and Get Shelter By Id. 
        -Put allows the user to update/edit fields for the shelter.
        -Delete allows the user to delete a shelter by id.

**Adopter, which includes first name, last name, city, state, and phone number. An adopterid is automatically assigned to the adopter upon creation. As we grow and learn, we will make adjustments to this table. At present, 1 is used for pets that are available for adoption.
    
    -Available endpoints in the adopter controller are POST, GET, PUT, DELETE.
        -Post allows for a user to add a new adopter.
        -Get: Two instances are included: Get All Adopters and Get Adopter By Id. 
        -Put allows the user to update/edit fields for the adopter.
        -Delete allows the user to delete an adopter by id.

**Domestic, for dogs and cats, which includes species, name, breed, sex, birthdate, adopterid, shelterid, and bools(true/false) for sterility, pet friendly, kid friendly,      hypoallergenic, housetrained, and declawed properties. A readonly bool for pending adoption will be false if the adoptionid entered is 1, if the adopterid is greater than 1, the pet will be listed as adoption pending. The domesticid is automatically assigned upon creation.

    -Available endpoints in the domestic controller are POST, GET, PUT, DELETE.
        -Post allows for a user to add a new domestic pet.
        -Get: Two instances are included: Get All Domestics and Get Domestics By Id. 
        -Put allows the user to update/edit fields for the domestic pet.
        -Delete allows the user to delete a domestic by id.

**Exotic, for exotic pets, which includes species, name, breed, sex, birthdate, adopterid, shelterid, and bools(true/false) for sterility, kid friendly, pet friendly, hypoallergenic, and legal in city properties. As with domestics, a readonly bool for pending adoption will be false if the adoptionid entered is 1, if the adopterid is greater than 1, the pet will be listed as adoption pending. The exoticid is automatically assigned upon creation.
    
    -Available endpoints in the exotic controller are POST, GET, PUT, and DELETE.
        -Post allows for a user to add a new exotic pet.
        -Get: Two instances are included: Get All Exotics and Get Exotics By Id. 
        -Put allows the user to update/edit fields for the exotic pet.
        -Delete allows the user to delete an exotic by id.

*Stretch goals included allowing users to sort the data by various properties.
    
    -Available endpoints in the pet controller are GET and PUT.
        -Get allows the user to sort domestics by AdopterId, ShelterId, Species, if HypoAllergenic, if Declawed, if House Trained and exotics by AdopterId, ShelterId, Species,               if HypoAllergenic, and if Legal in City.
        -Put allows the user to update the AdopterID of a domestic pet or an exotic pet.

The project has changed more than once. For our original iteration, we did not use n-tier architecture for our Web API. After closer examination and speaking with our instructor, Terry, we restarted this project and redid the tables more than once. We used Trello to track progress and make our goals. While we were not able to complete all of our stretch goals before the due date, we were able to complete our MVP and several of our stretch goals and we our happy with the outcome.


External Resources
During the creation of this app, we collaborated and tracked our progress using the following:

[Trello](https://trello.com/b/MtVranwy/api-project-pet-adopter) 

[GitHub](https://github.com/ALingo86/PetAdopter_API) 

[dbdiagram.io](https://dbdiagram.io/d/61eaffa87cf3fc0e7c52dabf)

