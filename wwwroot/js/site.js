let calendarDate = new Date(2026, 8, 1);
function initBookingCalendar(admin=false){ window.calendarAdmin=admin; renderCalendar(); }
function changeMonth(n){ calendarDate.setMonth(calendarDate.getMonth()+n); renderCalendar(); }
function renderCalendar(){
 const el=document.getElementById('calendar'); if(!el) return;
 document.getElementById('calendarTitle').textContent=calendarDate.toLocaleDateString('en-ZA',{month:'long',year:'numeric'});
 const y=calendarDate.getFullYear(), m=calendarDate.getMonth();
 const first=new Date(y,m,1).getDay(); const days=new Date(y,m+1,0).getDate();
 const names=['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
 el.innerHTML=names.map(x=>`<div class="cal-name">${x}</div>`).join('');
 for(let i=0;i<first;i++) el.innerHTML+='<div class="cal-cell empty"></div>';
 const busy=[5,12,18,26], mine=[12], blocked=[22,23];
 for(let d=1;d<=days;d++){
   let cls='available'; if(blocked.includes(d)) cls='blocked'; else if(mine.includes(d)&&!window.calendarAdmin) cls='mine'; else if(busy.includes(d)) cls='busy';
   const label=cls==='busy'?(window.calendarAdmin?'Booked':'Busy'):cls==='mine'?'Your event':cls==='blocked'?'Unavailable':'Open';
   el.innerHTML+=`<button type="button" class="cal-cell ${cls}" onclick="selectDate(${y},${m},${d},'${cls}')"><b>${d}</b><span>${label}</span></button>`;
 }
}
function selectDate(y,m,d,status){ if(status==='busy'||status==='blocked') return; const input=document.getElementById('bookingDate'); if(input){ const mm=String(m+1).padStart(2,'0'), dd=String(d).padStart(2,'0'); input.value=`${y}-${mm}-${dd}`; } }
function initPriceCalculator(){ ['eventType','hours','startTime','endTime'].forEach(id=>document.getElementById(id)?.addEventListener('change',calcPrice)); calcPrice(); }
function calcPrice(){
 const type=document.getElementById('eventType')?.value; let h=parseInt(document.getElementById('hours')?.value||'1'); let price=0;
 if(type==='Matric Ball') price=1500;
 if(type==='Wedding') price=2000+Math.max(0,h-6)*250;
 if(type==='Corporate Event') price=2500+Math.max(0,h-1)*200;
 if(type==='Birthday / Other') price=h*300;
 const out=document.getElementById('priceEstimate'); if(out) out.textContent='R'+price.toLocaleString('en-ZA');
}
