import { defineStore } from 'pinia'
import axios from 'axios'

export const useUserStore = defineStore('user-store', {
    state: () => {
        return {
            loaded: false,
            current: null
        }
    },

    getters: {
        
    },

    actions: {
        async getUserAsync(userId) {
            try {
                this.loaded = false;

                const response = await axios.get('user/getById', {
                    params: {
                        id: userId
                    }
                });

                this.current = response.data;
            } finally {
                this.loaded = true;
            }
        }
    }
})