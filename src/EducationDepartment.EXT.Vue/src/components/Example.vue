<template>
  <div class="example" style="margin-top:50px">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj przykład</h3>

    <form style ="margin-top:20px" v-on:submit="addExample">
      <div class="form-group">
       
          
          
            <div class="form-row">
          <div class="form-group col-md-6">
          <label for="autor">Autor</label>
          <input type="text" class="form-control"   placeholder="autor" v-model="example.autor">
          </div>
         <div class="form-group col-md-6">
          </br>
          <button type="button" class="btn btn-success mt-2">Dodaj siebie</button>
          </div>
         </div>

           

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control"  v-model="example.description" rows="5"></textarea>
            </br>


              <input class="form-control" type="date" value="2018-12-19" v-model="example.date">
                </br>
                     


                    </div>
                    <button   class="btn btn-lg btn-primary btn-block">Dodaj przykład</button>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Example',
  data(){
  return {
    example: {},
  alert: ""
        }
    },
  methods: {
  addExample(e) {
  if (
  !this.example.autor ||
  !this.example.description
  ) {
  this.alert = "Autor i opis to pola wymagane";
            } else {
  let newExample = {
  ContentFields: [
                        {}
                    ]
                }
  this.$http.post('http: //localhost:50906/api/Article/', newExample)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano przykład'
                        }
                    });
                });

  e.preventDefault();
            }
  e.preventDefault();
        }
    },
  components: {
  Alert
    }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
