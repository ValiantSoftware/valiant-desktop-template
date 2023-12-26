import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  root: "src",
  build: {
    outDir: '../dist'
  },
  server: {
    port: 8196,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'http://localhost:8195',
        changeOrigin: true,
        secure: false
      }
    }
  }
})
