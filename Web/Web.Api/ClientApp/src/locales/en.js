export default {
    common: { 
      "email": "Email",
      "name": "Name",
      "surname": "Surname",
      "password": "Password",
    },

    validations: {
      required: "Is required.",
      requiredIfRef: "Is required."
    },

    toast: {
      success: {
        title: "OK",
        description: "All good"
      },
      error: {
        title: "Error",
        description: "Something went wrong",
        validation_description: "Validation did not pass - some values are not valid."
      }
    },

    main: {
        header: {
            links: {
                "login": "Login",
                "register": "Register"
            }
        },
        footer: {
            
        },

        pages: {
            home: {
                
            },
            login: {
              "submit": "Login"
            },
            register: {
              "submit": "Register",
              "password_confirmation": "Password confirmation"
            }
        }
    }
}
