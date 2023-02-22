import { defineStore } from 'pinia'
import axios from 'axios'

export const useArticleStore = defineStore('article-store', {
    state: () => {
        return {
            loaded: false,
            articles: [],
            current: null
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

        async getArticleAsync(articleId) {
            try {
                this.loaded = false;

                const response = await axios.get('article/getById', {
                    params: {
                        id: articleId
                    }
                });

                this.current = response.data;
            } finally {
                this.loaded = true;
            }
        },

        async upsertArticleAsync() {
            try {
                this.loaded = false;

                const response = await axios.post('article/upsert', {
                    id: this.current.id,
                    title: this.current.title,
                    content: this.current.content                    
                });

                this.current = response.data;
            } finally {
                this.loaded = true;
            }
        },

        async deleteArticleAsync() {
            try {
                this.loaded = false;

                await axios.delete('article/delete', {
                    params: {
                        id: this.current.id
                    }
                });

                this.current = null;
            } finally {
                this.loaded = true;
            }
        }



    }
})