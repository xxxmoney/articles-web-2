export default {
    common: {
      "email": "Email",
      "name": "Jméno",
      "surname": "Příjmení",
      "password": "Heslo",
    },

    validations: {
      required: "Je požadováno.",
      requiredIfRef: "Je požadováno."
    },

    toast: {
      success: {
        title: "OK",
        description: "V pořádku"
      },
      error: {
        title: "Chyba",
        description: "Došlo k chybě",
        validation_description: "Došlo k chybě při validaci - některé hodnoty nejsou platné."
      }
    },

    main: {
        header: {
            links: {
                "login": "Příhlášení",
                "register": "Registrace"
            }
        },
        footer: {
            
        },

        pages: {
            home: {
                
            },
            login: {
              "submit": "Přihlásit se"
            },
            register: {
              "submit": "Registrovat se",
              "password_confirmation": "Potvrzení hesla"
            }
        }
    }
}
