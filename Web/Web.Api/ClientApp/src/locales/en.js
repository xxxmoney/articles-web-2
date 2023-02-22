export default {
    common: { 
      "email": "Email",
      "name": "Name",
      "surname": "Surname",
      "password": "Password",
      "detail": "Detail",
      "by": "By"
    },

    validations: {
      required: "Is required.",
      requiredIfRef: "Is required.",
      email: "Email is not valid.",
      is_equal: "Values do not match."
    },

    toast: {
      success: {
        title: "OK",
        description: "All good"
      },
      error: {
        title: "Error",
        description: "Something went wrong",
        validation_description: "Incorrect values."
      }
    },

    main: {
        header: {
            links: {
                "home": "Home",
                "articles": "Articles",
                "login": "Login",
                "register": "Register",
                "profile": "Profile",
                "logout": "Logout"
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
