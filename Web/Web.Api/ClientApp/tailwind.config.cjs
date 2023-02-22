/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require("daisyui")
  ],

  daisyui: {
    themes: [
      {
        mytheme: {        
          "primary": "#1C4E80",                  
          "secondary": "#7C909A",                  
          "accent": "#EA6947",                  
          "neutral": "#23282E",                  
          "base-100": "#202020",                  
          "info": "#0091D5",                  
          "success": "#6BB187",                  
          "warning": "#DBAE59",                  
          "error": "#AC3E31",
        },
      },
    ],
  }
}
