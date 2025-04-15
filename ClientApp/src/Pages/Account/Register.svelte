<script lang="ts">
    import logo from "@assets/images/logo.png";
    
    let currentType: "business" | "individual" | "" = "";
</script>

<div class="container">
    <div class="form">
        <img class="logo" src={logo} alt="logo" width="320">
        
        <h1 class="title">Account Registration</h1>
        
        <h2 class="type-title">Select your account type</h2>
        <div class="type-selector">
            <button class="type-item left {currentType === 'individual' ? 'active' : ''}" on:click="{() => {currentType = 'individual'}}">Individual</button>
            <button class="type-item right {currentType === 'business' ? 'active' : ''}" on:click="{() => {currentType = 'business'}}">Business</button>
        </div>
    </div>
</div>

<style lang="scss">
  .container {
    height: 100vh;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }
  
  .form {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background-color: #F7F7F7;
    border-radius: 10px;
    padding: 20px;
    
    .title {
      color: #3572EF;

      &::after {
        content: "";
        display: block;
        position: relative;
        width: 70%;
        height: 2px;
        left: calc(50% - 35%);
        background-color: #3572EF;
      }
    }
    
    .type-title {
      font-size: 1.1rem;
    }
    
    .type-selector {
      display: flex;
      flex-direction: row;
      justify-content: center;
      align-items: center;
      margin-top: 4px;
      
      .type-item {
        background-image: url('https://web.archive.org/web/20160312084140im_/http://splatoon.nintendo.com/assets/img/nav-bg-fill-blue.png?1443460871');
        background-repeat: repeat-x;
        background-position: 0 -100%;
        transition: 1.2s ease;
        color: #3572EF;
        padding: 10px 20px;
        cursor: pointer;
        border: 1px solid #3572EF;
        
        &.active {
          background-position: center;
          color: white;
        }
        
        &.left {
          border-radius: 10px 0px 0px 10px;
        }
        
        &.right {
          border-radius: 0px 10px 10px 0px;
        }

        &:hover{
          background-position: center;
          color: white;
        }
      }
    }
  }
</style>