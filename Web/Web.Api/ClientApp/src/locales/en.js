export default {
    common: { 
      email: "Email",
      name: "Name",
      surname: "Surname",
      password: "Password",
      detail: "Detail",
      by: "By",
      save: "Save",
      delete: "Delete",
      confirmation: "Confirmation",
      delete_confirmation: "Are you sure you want to delete this record?",
      create: "Create",
      upload: "Upload"
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
                home: "Home",
                articles: "Articles",
                login: "Login",
                register: "Register",
                profile: "Profile",
                logout: "Logout"
            }
        },
        footer: {
            
        },

        pages: {
            home: {
              title: "Welcome",
              subtitle: "Welcome to GreatArticles website, where you can read and write your own articles.",
              get_started: "Get Started"
            },
            login: {
              submit: "Login"
            },
            register: {
              submit: "Register",
              password_confirmation: "Password confirmation"
            }
        }
    }
}
