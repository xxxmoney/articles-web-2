import { defineStore } from 'pinia'
import axios from 'axios'
import { LocalUserHelper } from '../helpers/LocalUserHelper'

export const useAuthStore = defineStore('auth-store', {
    state: () => {
        return {
            loaded: false,
            user: LocalUserHelper.getUser()
        }
    },

    getters: {
        /** Returns true if user is logged in. */
        isLoggedIn() {
          return !!this.user;
        }
    },

    actions: {
        /** Sends request for login and sets user. */
        async loginAsync(email, password) {
          try {
            this.loaded = false;

            const response = await axios.post('auth/login', {
              Email: email,
              Password: password
            });
              
            this.user = response.data;
            LocalUserHelper.setUser(this.user);
          } finally {
            this.loaded = true;
          }
        },

        /** Sends request for register. */
        async registerAsync(name, surname, email, password) {
          try {
            this.loaded = false;

            await axios.post('auth/register', {
              Name: name,
              Surname: surname,
              Email: email,
              Password: password
            });
          } finally {
            this.loaded = true;
          }
        },

        /** Logs out by deleting local user. */
        logout() {
          LocalUserHelper.deleteUser();
          this.user = null;
        },

        /** Sends request to verify if user is authenticated. */
        async verifyAuthenticatedAsync() {
          if (!this.user) {
            return false;
          }

          try {
            this.loaded = false;

            await axios.get('auth/verifyAuthenticated');
          } catch {
            this.logout();
            return false;
          }
          finally {
            this.loaded = true;
          }

          return true;
        }
      }
})