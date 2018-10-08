<template>
    <div class="login">
            <h1>Welcome to Keepr</h1>
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#"></a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#"></a>
                    </li>
                </ul>
                <span class="navbar-text float-left">
                    <h3>Keepr</h3>
                </span>
            </div>
        </nav>
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>
<style>
    .login {
        /* display:flex; */
        color: #4C8302;
  font-family: 'Oregano', cursive;
    }
    h1 {
  /* margin-top: 5rem; */
  font-size:100px;
  color: #4C8302;
  font-family: 'Oregano', cursive;
  
}
p {
    color: #83B312;
  font-family: 'Oregano', cursive;
}
.Login {
  background-color:#163C00;
  height: 100vh;
}
html {
  background-color:#163C00;
}

</style>