        //Buttons Hidden Operations
        document.querySelector("#table1").hidden = false;
        function gizle1() {
        document.querySelector("#form1").hidden = false;
        document.querySelector("#table1").hidden = true;
        }
        function gizle2() {
        document.querySelector("#form1").hidden = true;
        document.querySelector("#table1").hidden = false;
        }
        function gizlee3(){
        document.querySelector("#search").hidden = false;
        }
        //Bottom and Up buttons
        document.querySelector("#bottom-btn").hidden = false;
        function gizleGoster1(){
            document.querySelector("#bottom-btn").hidden = true;
            document.querySelector("#yukari").hidden = false;
        }
        function gizleGoster2(){
            document.querySelector("#bottom-btn").hidden = false;
            document.querySelector("#yukari").hidden = true;
        }

        //Update Students
        function fetchStudents() {
            fetch('https://localhost:7126/api/Students')
                .then(response => response.json())
                .then(data => {
                    const tableBody = document.getElementById('studentTableBody');
                    tableBody.innerHTML = ''; 
                    data.forEach(student => {
                        const row = `<tr>
                                    <td>${student.id}</td>                                
                                    <td>${student.firstName}</td>
                                    <td>${student.lastName}</td>                                
                                    <td>${student.ardress}</td>                                
                                    <td>${student.studentClass}</td>                               
                                    <td>                                                               
                                    <button onclick="updateStudent(${student.id})" class="btn btn-warning"><img src="update.svg" alt="" style="width: 15px;"> Update</button>                                    
                                    <button onclick="deleteStudent(${student.id})" class="btn btn-danger"><img src="delete.svg" alt="" style="width: 15px;"> Delete</button>                                    
                                    </td>                                
                                    </tr>`;                           
                        tableBody.innerHTML += row;
                    });
                    
                })
                .catch(error => console.error('Hata:', error));
        }

        //Delete Students 
        function deleteStudent(id) {
            if (confirm('Are you sure you want to delete the student ?')) {
                fetch(`https://localhost:7126/api/Students/${id}`, {
                    method: 'DELETE',
                })
                    .then(response => {
                        if (response.ok) {
                            alert('The student has been deleted successfully.');
                            fetchStudents();
                        } else {
                            alert('An error occurred while deleting the student.');
                        }
                    })
            }
        }     
        window.onload = function () {
            fetchStudents();
        };
        // Moves to top of page
        $('#yukari').on('click',function(){
            $('html,body').animate({scrollTop:0})
        });
        // Moves to bottom of page
        $(document).ready(function () {
            $('#bottom-btn').on('click',function(){
                $(window).scrollTop($(document).height());
            });
        });
        //Refresh Page
        function sayfayiYenile()
        {
            window.location.reload()
        }
        function updateStudent(id) {
            window.location.href = `http://127.0.0.1:5500/updateStudent.html?id=${id}`;
        }
        $(function(){
            $("#search").on("keyup",function(){
                var name=$(this).val().toLowerCase();
                $("#studentTableBody tr td:nth-child(1)").filter(function(){
                    $(this).parent().toggle($(this).text().toLowerCase().indexOf(name)>-1);
                });
            });
        });