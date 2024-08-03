using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using server_api.Data;
using server_api.DTOs;
using server_api.Entities;

namespace server_api.Controllers
{
    public class CouponController : BaseApiController
    {
        private readonly DataContext _context;
        public CouponController(DataContext context)
        {
            this._context = context;
        }

        // api/coupon/create-coupon{body}
        [HttpPost("create-coupon")]
        [Authorize]
        public async Task<ActionResult<GeneratedCouponDetail>> CreateCoupon(GenerateCouponParamDTO generateCouponParamDTO)
        {
            // 1. using sql
            // var serviceCode = "DHSE";
            // var subServiceCode="YEFOR";
            // var kioskId =1;

            // var coupon = this._context.IPTVMachines
            //         .FromSqlRaw($"EXECUTE up_CreateCoupon {serviceCode}, {subServiceCode}, {BiometricNo}, {kioskId}")
            //         .ToList();

            // 2. using parameter
            var serviceCodeParam = new SqlParameter("@ServiceCode", generateCouponParamDTO.ServiceCode);
            var subServiceCodeParam = new SqlParameter("@SubServiceCode", generateCouponParamDTO.SubServiceCode);
            var BiometricNoParam = new SqlParameter("@BiometricNo", generateCouponParamDTO.BiometricNo);
            var kioskIdParam = new SqlParameter("@KioskId", generateCouponParamDTO.KioskId);

            var coupons = await this._context.GeneratedCouponDetails
                    .FromSqlRaw("EXECUTE up_CreateCoupon @ServiceCode, @SubServiceCode, @KioskId", serviceCodeParam, subServiceCodeParam,BiometricNoParam, kioskIdParam)
                    .ToListAsync();

            if (coupons != null && coupons.Count > 0)
                return Ok(coupons);
            else
                return NotFound();
        }

        // api/coupon/get-next-pending-coupon{body}
        [HttpPost("get-next-pending-coupon")]
        [Authorize]
        public async Task<ActionResult<NextPendingCoupon>> GetNextPendingCoupon(NextPendingCouponDTO nextPendingCouponDTO)
        {
            var DeskId = new SqlParameter("@DeskId", nextPendingCouponDTO.DeskId);
            var BoxId = new SqlParameter("@BoxId", nextPendingCouponDTO.BoxId);
            var BoxUserId = new SqlParameter("@BoxUserId", nextPendingCouponDTO.BoxUserId);

            var pendingCoupons = await this._context.NextPendingCoupons
                    .FromSqlRaw("EXECUTE up_GetNextPendingCoupon @DeskId, @BoxId, @BoxUserId", DeskId, BoxId, BoxUserId)
                    .ToListAsync();

            if (pendingCoupons != null && pendingCoupons.Count > 0)
                return Ok(pendingCoupons);
            else
                return NotFound();
        }

        // api/coupon/update-coupon-status{body}
        [HttpPost("update-coupon-status")]
        [Authorize]
        public async Task<ActionResult<bool>> MarkCouponFinish(UpdateCouponStatusDTO updateCouponStatusDTO)
        {
            var coupon = await this._context.Coupons.FindAsync(updateCouponStatusDTO.CouponId);
            if (coupon == null)
            {
                return NotFound(false);
            }
            else
            {
                switch (updateCouponStatusDTO.Status.ToUpper())
                {
                    case "F":
                        coupon.IsCompleted = true;
                        break;
                    case "A":
                        coupon.IsAbsent = true;
                        break;
                    default:
                        break;
                }

                coupon.IsInProgress = null;
                coupon.CompletionDateTime = DateTime.Now;
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}