﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SaleSpec.Master" AutoEventWireup="true" CodeBehind="newprojectreport.aspx.cs" Inherits="SaleSpec.pages.report.newprojectreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script src="jquery-1.11.2.min.js"></script>
    <style>
        .myclass {
            color: blue;
            
        }

        .mypointer {
            cursor: pointer;
            color: darkblue;
            font-weight: normal;
        }

        .mypointer:hover {
            cursor: pointer;
            color: red;
            font-weight: bold;
        }

        .mypointerid {
            cursor: pointer;
            color: darkblue;
            font-weight: normal;
        }
    </style>

   
    <script>

        document.addEventListener("keyup", function (e) {
            var keyCode = e.keyCode ? e.keyCode : e.which;
            if (keyCode == 44) {
                stopPrntScr();
            }
        });

        function stopPrntScr() {

            var inpFld = document.createElement("input");
            inpFld.setAttribute("value", ".");
            inpFld.setAttribute("width", "0");
            inpFld.style.height = "0px";
            inpFld.style.width = "0px";
            inpFld.style.border = "0px";
            document.body.appendChild(inpFld);
            inpFld.select();
            document.execCommand("copy");
            inpFld.remove(inpFld);
        }
        function AccessClipboardData() {
            try {
                window.clipboardData.setData('text', "Access   Restricted");
            } catch (err) {
            }
        }

        setInterval("AccessClipboardData()", 300);

        window.onload = function () {
            document.addEventListener("contextmenu", function (e) {
                Swal.fire(
                    'This page is protected..!',
                    'Do not copy or export data.',
                    'error'
                )
                e.preventDefault();
            }, false);
            document.addEventListener("keydown", function (e) {
                if (e.keyCode === 13) {
                       // Cancel the default action, if needed
                       e.preventDefault();
                       // Trigger the button element with a click
                       document.getElementById("btnJsonReport").click();
                }

                //document.onkeydown = function(e) {
                // "C" key
                if (e.ctrlKey && e.keyCode == 67) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }


                // "F" key
                if (e.altKey && e.keyCode == 70) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }
                // "I" key
                if (e.ctrlKey && e.shiftKey && e.keyCode == 73) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }
                // "J" key
                if (e.ctrlKey && e.shiftKey && e.keyCode == 74) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }

                // "P" key
                if (e.ctrlKey && e.keyCode == 80) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }

                // "S" key + macOS
                if (e.keyCode == 83 && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey)) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }
                // "U" key
                if (e.ctrlKey && e.keyCode == 85) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }
                // "V" key
                if (e.ctrlKey && e.keyCode == 86) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not copy or export data.',
                        'error'
                    )
                    disabledEvent(e);
                }

                // "F12" key
                if (event.keyCode == 123) {
                    Swal.fire(
                        'This page is protected..!',
                        'Do not open source tag.',
                        'error'
                    )
                    disabledEvent(e);
                }
            }, false);
            function disabledEvent(e) {
                if (e.stopPropagation) {
                    e.stopPropagation();
                } else if (window.event) {
                    window.event.cancelBubble = true;
                }
                e.preventDefault();
                return false;
            }
        };

        $(document).ready(function () {

            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0');
            var yyyy = today.getFullYear();
            var tt = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();

            var firstdate = yyyy + '-' + mm + '-01';
            var currentdate = yyyy + '-' + mm + '-' + dd;


            var datepickertrans = $('#datepickertrans');
            var datepickerend = $('#datepickerend');
            datepickertrans.val(firstdate);
            datepickerend.val(currentdate);

            var btnJsonReport = $('#btnJsonReport');
            btnJsonReport.click(function () {
                var selectSaleport = $('#selectSalePort').val();
                var datepickertrans = $('#datepickertrans').val();
                var datepickerend = $('#datepickerend').val();
                var qtystart = $('#QuantityStart').val();
                var qtyend = $('#QuantityEnd').val();
                var strsearch = $('#Search').val()

                $.ajax({
                    url: 'DataServicesReporting.asmx/GetNewProjectReporting',
                    method: 'post',
                    data: {
                        strUserID: selectSaleport,
                        strStartDate: datepickertrans,
                        strEndDate: datepickerend,
                        strQtyStart: qtystart,
                        strQtyEnd: qtyend,
                        strSearch: strsearch
                    },
                    dataType: 'json',
                    success: function (data) {

                        var table;
                        table = $('#tableWeeklyReportx').DataTable();
                        table.clear();

                        if (data != '') {
                            $.each(data, function (i, item) {
                                table.row.add([data[i].WeekDate, data[i].WeekTime, data[i].CompanyName, data[i].ArchitecID, data[i].Name, data[i].ProjectName, data[i].Location
                                    , data[i].StatusNameEn, data[i].StepNameEn, data[i].Remark, data[i].Quantity, data[i].CreatedDate]);
                            });
                        }
                        table.column(3).nodes().to$().addClass('hidden');

                        table.column(2).nodes().to$().addClass('mypointer');
                        table.column(4).nodes().to$().addClass('mypointer');
                        table.column(5).nodes().to$().addClass('mypointer');
                        table.column(10).nodes().to$().addClass('mypointer');

                        table.draw();
                        //$('#tableWeeklyReportx td:nth-of-type(5)').addClass('myclass');
                        //$('#tableWeeklyReportx td:nth-of-type(6)').addClass('myclass');
                        // $('#tableWeeklyReportx td:nth-child(4),th:nth-child(4)').hide();

                        //var example1 = $('#tableWeeklyReportx');
                        //$('#tableWeeklyReportx td').hover(function () {
                        //    rIndex = this.parentElement.rowIndex;
                        //    cIndex = this.cellIndex;
                        //    if (rIndex != 0 & cIndex == 2 || cIndex == 4 || cIndex == 5 || cIndex == 10) {
                        //        $(this).css('cursor', 'pointer');
                        //        $(this).css('color', 'red');
                        //        $(this).css('font-weight', 'bold');
                        //    }
                        //}, function () {
                        //    rIndex = this.parentElement.rowIndex;
                        //    cIndex = this.cellIndex;
                        //    if ((rIndex != 0 & cIndex == 2 || cIndex == 4 || cIndex == 5 || cIndex == 10)) {
                        //        $(this).css("color", "blue");
                        //        $(this).css('font-weight', 'normal');
                        //    }
                        //});

                        //$('#tableWeeklyReportx td').click(function () {
                        //    rIndex = this.parentElement.rowIndex;
                        //    cIndex = this.cellIndex;

                        //    if (rIndex != 0 & cIndex == 2 || cIndex == 4 || cIndex == 5 || cIndex == 10) {
                        //        var strarcid = $("#tableWeeklyReportx").find('tr:eq(' + rIndex + ')').find('td:eq(3)').text().replace(' ', '');
                        //        //alert(strarcid);
                        //        window.open("../report/architectprofile.aspx?opt=rarc&id=" + strarcid + "", "_blank");
                        //    }
                        //});

                         $('#tableWeeklyReportx tbody').on('click', 'td', function (e) {
                            e.preventDefault();
                            var rowIndex = $(this).parent().children().eq(4).text(); //  $(this).closest('.mypointer').text();
                            var rowValue = $(this).parent().children().eq(5).text();
                            console.log(rowIndex + ':' + rowValue);

                            rIndex = this.parentElement.rowIndex;
                            cIndex = this.cellIndex;

                            console.log('row : ' + rIndex + 'cell : ' + cIndex);

                             if (rIndex != 0 & cIndex == 2 || cIndex == 4 || cIndex == 5 || cIndex == 10) {
                                var strarcid = $("#tableWeeklyReportx").find('tr:eq(' + rIndex + ')').find('td:eq(3)').text().replace(' ', '');
                                window.open("../report/architectprofile.aspx?opt=rarc&id=" + strarcid + "", "_blank");
                            }
                        });


                    }
                });
            });

            //var btnExportExcel = $('#btnExportExcel');
            var btnExportExcel = $('#btnExportExcel')
            btnExportExcel.click(function () {

                $('#txtRepOpt').val('EXCEL');

                $("#myModalVerifyPassword").modal({ backdrop: false });
                $("#myModalVerifyPassword").modal("show");
            });

             var btnExportPDF = $('#btnExportPDF')
            btnExportPDF.click(function () {

                $('#txtRepOpt').val('PDF');

                $("#myModalVerifyPassword").modal({ backdrop: false });
                $("#myModalVerifyPassword").modal("show");
            });


        })
    </script>

     <!-- Header content -->
    <section class="content-header">
        <h1>New Project Report
            <small>Control panel</small>
        </h1>
    </section>

    <!-- Main content -->
    <section class="content">
           <%= strMsgAlert %>

        <%-- Application Forms--%>
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <div class="box-body">

                            <div id="divOption">
                                <div class="user-block">
                                    <img class="img-circle img-bordered-sm" src="../../dist/img/handshake.png" alt="User Image">
                                    <span class="username">
                                        <a href="#">New Project Report</a>
                                        <span class="pull-right">
                                        <button type="button" class="btn btn-default btn-sm checkbox-toggle hidden" onclick="openModal()" data-toggle="tooltip" title="New Entry!">
                                            <i class="fa fa-plus"></i>
                                        </button>
                                        <span class="btn-group">
                                            <%--<button id="btnDownload" runat="server" onserverclick="btnDownload_click" type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF"><i class="fa fa-download"></i></button>
                                            <button type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print PDF" onclick="window.print()"><i class="fa fa-credit-card"></i></button>
                                            <button id="btnExportExcel" runat="server" onserverclick="btnExportExcel_click" type="button" class="btn btn-default btn-sm" data-toggle="tooltip" title="Print Excel"><i class="fa fa-table"></i></button>
                                        --%>

                                        </span>
                                    </span>

                                    </span>
                                    <span class="description">Details for weekly report</span>
                                </div>


                                <%--<div class="row" style="margin-left: 30px;">
                                    <div class="col-md-4">
                                        <label class="txtLabel">Select Reports</label>
                                        <div class="txtLabel">
                                            <select id="selectReportType" name="selectReportType" class="form-control input-sm" style="width: 100%">
                                                <option value="1">New Project</option>
                                                <option value="2">Spec Intake</option>
                                                <option value="3">Step Design > Bidding </option>
                                                <option value="4">Step Bidding > Award MC</option>
                                                <option value="5">Step Award RF > Award RF </option>
                                                <option value="6">Project Bidding </option>
                                                <option value="7">Project Award MC</option>
                                                <option value="8">Project Award RF</option>
                                                <option value="9">Weekly Report</option>
                                                <option value="10">Next Visit</option>
                                            </select>
                                        </div>
                                        <div id="divErrorselectReportType" class="txtLabel text-red" style="display: none;">Please select a owner...!</div>
                                    </div>
                                </div>--%>

                                <div class="row" style="margin-left: 30px;">
                                    <div class="col-md-4 hidden">
                                        <label class="txtLabel">Project</label>
                                        <div class="txtLabel">
                                            <select id="selectProject" name="selectProject" class="form-control input-sm" style="width: 100%">
                                            </select>
                                        </div>
                                        <div id="divErrorSelectProject" class="txtLabel text-red" style="display: none;">Please select a project...!</div>
                                    </div>

                                    <div class="col-md-4">
                                        <label class="txtLabel">Sale Spec</label>
                                        <div class="txtLabel">
                                            <select id="selectSalePort" name="selectSalePort" class="form-control input-sm" style="width: 100%">
                                                <%= strPortOption %>
                                            </select>
                                        </div>
                                        <div id="divErrorSelectSaleSpec" class="txtLabel text-red" style="display: none;">Please select a owner...!</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">From Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickertrans" name="datepickertrans" value="" autocomplete="off">
                                            <div class="input-group-addon input-sm">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">End Date</label>
                                        <div class="input-group date">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="datepickerend" name="datepickerend" value="" autocomplete="off">
                                            <div class="input-group-addon input-sm">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>

                                    
                                </div>

                                <div class="row" style="margin-left: 30px;">
                                    <div class="col-md-2">
                                        <label class="txtLabel">From Quantity </label>
                                        <div class="txtLabel">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="QuantityStart" name="QuantityStart" value="" autocomplete="off">
                                        </div>
                                        <div id="divErrorQuantityStart" class="txtLabel text-red" style="display: none;">Please select a owner...!</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">To Quantity</label>
                                        <div class="txtLabel">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="QuantityEnd" name="QuantityEnd" value="" autocomplete="off">

                                         </div>
                                        <div id="divErrorQuantityEnd" class="txtLabel text-red" style="display: none;">Please select a owner...!</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">Search</label>
                                        <div class="txtLabel">
                                            <input type="text" class="form-control input-sm pull-left txtLabel" id="Search" name="Search" value="" autocomplete="off"  placeholder="Can you search data in here..">

                                         </div>
                                        <div id="divErrorSearch" class="txtLabel text-red" style="display: none;">Please select a owner...!</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">Query Info</label>
                                        <div class="">
                                            <%--<button type="button" id="btnQuery" runat="server" onserverclick="btnQuery_Click" class="btn btn-info btn-flat btn-block btn-sm hidden" >Show Report</button>--%>
                                            <button type="button" id="btnJsonReport" class="btn btn-info btn-flat btn-block btn-sm " >Show Report</button>
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="txtLabel">Reporting</label>
                                        <div>
                                            <span class="btn-group">
                                                <button id="btnExportPDF" type="button" class="btn btn-danger btn-flat btn-sm " style="width: 50%" title="Print PDF">
                                                    <i class="fa fa-file-pdf-o"></i> Print PDF</button>
                                               <button id="btnExportExcel" type="button" class="btn btn-success btn-flat btn-block btn-sm " style="width: 50%" title="Print Excel">
                                                <i class="fa fa-file-excel-o"></i>Print Excel</button>
                                            </span>
                                        </div>
                                    </div>


                                </div>
                            </div>

                            <hr />

                            <div class="row">
                                <div id="divWeeklyReport" >

                                    <table id="tableWeeklyReportx" class="table table-bordered table-striped table-hover table-condensed txtLabel" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>Date</th>
                                                <th>Time</th>
                                                <%--<th>ComID</th>--%>
                                                <th>ComName</th>
                                                <th class="hidden">ArchID</th>
                                                <th>Architech</th>
                                                <%--<th>ProjID</th>--%>
                                                <th>ProjName</th>
                                                <th>Location</th>                                                
                                                <th>Status</th>                                                
                                                <th>StepNameEn</th>
                                                <th>Details</th>
                                                <th>Quantity</th>
                                                <th>Updated</th>

                                               <%-- WeekDate, WeekTime, CompanyName, ArchitecID, Name, ProjectName, Location
                                    , StatusNameEn, StepNameEn, Remark, Quantity, CreatedDate--%>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <%-- <%= strTblDetail %>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- /.modal myModalVerifyPassword -->
        <div class="modal modal-default fade" id="myModalVerifyPassword">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Request Email</h4>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="post clearfix">
                                <div class="row" style="margin-bottom: 5px">
                                    <div class="col-md-4 txtLabel">Enter Your Email</div>
                                    <div class="col-md-8">
                                        <input type="text" class="form-control input input-sm txtLabel" id="txtConfirmEmail" name="txtConfirmEmail" autocomplete="off" placeholder="" value="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer clearfix">
                        <input type="text" id="txtRepOpt" name="txtRepOpt" class="hidden" value="" />
                        <%--<asp:Button ID="btnSendMail" runat="server" Text="btnSendMail" OnClick="btnSendMail_Click" CssClass="" />--%>
                        <button class="btn btn-default hidden" id="btnSendmail" runat="server" onserverclick="btnSendMail_Click" >Send Mail</button>

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="btnConfirmed" runat="server" onclick="sendMail()">Submit Request</button>
                    </div>
                </div>
            </div>
        </div>

        <script>
             function sendMail() {                
                document.getElementById("<%= btnSendmail.ClientID %>").click();
             }
        </script>
    </section>

    
</asp:Content>
