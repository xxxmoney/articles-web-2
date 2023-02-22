import { defineStore } from 'pinia'
import axios from 'axios'

export const useArticleStore = defineStore('article-store', {
    state: () => {
        return {
            loaded: false,
            articles: []
        }
    },

    getters: {
        
    },

    actions: {
        async getArticlesAsync(articleId = null, userId = null) {
            try {
                this.loaded = false;

                this.articles = [];
                const response = await axios.get('article/getAll', {
                    params: {
                        articleId: articleId,
                        userId: userId
                    }
                });

                this.articles = response.data;
            } finally {
                this.loaded = true;
            }
        },


    }
})