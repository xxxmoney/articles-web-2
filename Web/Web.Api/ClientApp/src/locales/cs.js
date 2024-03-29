export default {
    common: {
      email: "Email",
      name: "Jméno",
      surname: "Příjmení",
      password: "Heslo",
      detail: "Detail",
      by: "Od",
      save: "Uložit",
      delete: "Smazat",
      confirmation: "Potvrzení",
      delete_confirmation: "Opravdu chcete smazat tento záznam?",
      create: "Vytvořit",
      upload: "Nahrát"
    },

    validations: {
      required: "Je požadováno.",
      requiredIfRef: "Je požadováno.",
      email: "Email není platný.",
      is_equal: "Hodnoty se neshodují."
    },

    toast: {
      success: {
        title: "OK",
        description: "V pořádku"
      },
      error: {
        title: "Chyba",
        description: "Došlo k chybě",
        validation_description: "Některé hodnoty nejsou platné."
      }
    },

    main: {
        header: {
            links: {
                home: "Hlavní stránka",
                articles: "Články",
                login: "Příhlášení",
                register: "Registrace",
                profile: "Profil",
                logout: "Odhlásit se"
            }
        },
        footer: {
            
        },

        pages: {
            home: {
                title: "Vítejte",
                subtitle: "Vítejte na webu GreatArticles, kde můžete číst a psát vlastní články.",
                get_started: "Začít"
            },
            login: {
              submit: "Přihlásit se"
            },
            register: {
              submit: "Registrovat se",
              password_confirmation: "Potvrzení hesla"
            }
        }
    }
}
