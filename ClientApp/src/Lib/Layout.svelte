<script>
    import {inertia} from "@inertiajs/inertia-svelte";
    import backgroundVideo from "@assets/videos/background.mp4";

    let {children} = $props();
</script>

<main>
    <div class="background">
        <video autoplay muted loop playsinline>
            <source src={backgroundVideo} type="video/mp4">
        </video>
    </div>
    
    <article class="content">
        {@render children()}
    </article>

    <footer>
        <div class="copyright">
            © {new Date().getUTCFullYear()} UnxWares. All rights reserved 
        </div>
        <nav class="links">
            <a href="/legal">Legal</a>
            <a href="/terms">Terms</a>
            <a href="/privacy">Privacy</a>
            <a href="/contact">Support</a>
        </nav>
    </footer>
</main>

<style lang="scss">
  main {
    display: flex;
    flex-direction: column;
    background-color: transparent;
  }

  .background {
    position: fixed;
    inset: 0;
    width: 100%;
    height: 100%;
    overflow: hidden;
    z-index: -1;
  }

  .background video {
    width: 100%;
    height: 100%;
    object-fit: cover;
    display: block;
  }

  .content {
    flex: 1;
    min-height: 100%;
    overflow: auto;
  }

  footer {
    display: flex;
    position: fixed;
    width: 100%;
    bottom: 0;
    flex-direction: column;
    align-items: center;
    
    &::after {
      content: "";
      display: block;
      width: 100px;
      height: 3px;
      background-color: #fff;
      position: absolute;
      top: -10px;
      left: calc(50% - 50px);
      border-radius: 5px;
    }
    
    .copyright {
      margin: 0 auto;
      padding: 0.5rem;
      color: #fff;
      text-align: center;
    }
    
    .links {
      display: flex;
      gap: 1rem;
      padding: 0.5rem;
      
      a {
        color: #fff;
        text-decoration: none;
        font-size: 0.95rem;
      }
    }
  }
</style>